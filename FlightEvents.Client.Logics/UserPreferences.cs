﻿using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FlightEvents.Client.Logics
{
    public class UserPreferences
    {
        public string LastCallsign { get; set; }
    }

    public class UserPreferencesLoader
    {
        private readonly string filePath;

        public UserPreferencesLoader(string filePath)
        {
            this.filePath = filePath;
        }

        private static readonly SemaphoreSlim sm = new SemaphoreSlim(1);

        public async Task<UserPreferences> LoadAsync()
        {
            try
            {
                await sm.WaitAsync();

                return await LoadFromFileAsync();
            }
            finally
            {
                sm.Release();
            }
        }

        public async Task<UserPreferences> UpdateAsync(Action<UserPreferences> updateAction)
        {
            _ = updateAction ?? throw new ArgumentNullException(nameof(updateAction));

            try
            {
                await sm.WaitAsync();

                var pref = await LoadFromFileAsync();
                updateAction(pref);
                await SaveToFileAsync(pref);
                return pref;
            }
            finally
            {
                sm.Release();
            }
        }

        private Task SaveToFileAsync(UserPreferences pref)
        {
            if (File.Exists(filePath)) File.Move(filePath, filePath + ".bak", true);
            using var stream = File.Create(filePath);
            return JsonSerializer.SerializeAsync(stream, pref);
        }

        private async Task<UserPreferences> LoadFromFileAsync()
        {
            if (File.Exists(filePath))
            {
                using var stream = File.OpenRead(filePath);
                return await JsonSerializer.DeserializeAsync<UserPreferences>(stream);
            }
            else
            {
                return new UserPreferences();
            }
        }
    }
}