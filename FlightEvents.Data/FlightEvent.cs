﻿using System;
using System.Collections.Generic;

namespace FlightEvents.Data
{
    public enum FlightEventType
    {
        SightSeeing,
        ATC,
        Race
    }

    public class FlightEvent
    {
        // HACK: defaultValue in HotChocolate seems to assign wrong date when DateTimeOffset.MinValue is used
        // hence we introduce a different default
        public static readonly DateTimeOffset DefaultDateTimeOffset = new DateTimeOffset(1000, 1, 1, 0, 0, 0, TimeSpan.Zero);

        public Guid Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset UpdatedDateTime { get; set; }

        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }

        public FlightEventType? Type { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public string Waypoints { get; set; }
        public string Route { get; set; }

        public string StopwatchCode { get; set; }
        public List<string> Leaderboards { get; set; }
        public List<string> LeaderboardLaps { get; set; }
        public List<string> RacerCallsigns { get; set; }
        public List<string> MarkedWaypoints { get; set; }

        public List<string> FlightPlanIds { get; set; }

        public void UpdateTo(FlightEvent current)
        {
            if (StartDateTime > DefaultDateTimeOffset) current.StartDateTime = StartDateTime;
            if (EndDateTime != default) current.EndDateTime = EndDateTime;

            if (Type != default) current.Type = Type;

            if (Name != default) current.Name = Name;
            if (Description != default) current.Description = Description;
            if (Url != default) current.Url = Url;

            if (Waypoints != default) current.Waypoints = Waypoints;
            if (Route != default) current.Route = Route;

            if (StopwatchCode != default) current.StopwatchCode = StopwatchCode;

            if (Leaderboards != default) current.Leaderboards = Leaderboards;
            if (LeaderboardLaps != default) current.LeaderboardLaps = LeaderboardLaps;
            if (RacerCallsigns != default) current.RacerCallsigns = RacerCallsigns;
            if (MarkedWaypoints != default) current.MarkedWaypoints = MarkedWaypoints;

            if (FlightPlanIds != default) current.FlightPlanIds = FlightPlanIds;
        }
    }
}
