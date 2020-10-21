## Flight Events

![.NET Core](https://github.com/nguyenquyhy/Flight-Events/workflows/.NET%20Core/badge.svg)

This is a system to enhance the experience of flying in group with friends.

This includes:
- A server to handle 2-way communications. The web server also provides with a web interface to display all participating aircraft and upcoming events.
- A client to communicate with flight simulators via SimConnect and send data to the server.
- The same client can also serve as a simplified FSD server for ATC radar software such as Euroscope or AURORA.
- A Discord bot to automatically move players between voice channels based on their COM1 frequency
https://discordapp.com/api/oauth2/authorize?client_id={BOT_CLIENT_ID}&scope=bot&permissions=221249553

### NOTES

- The client automatically forces single instance unless `--multiple-instances` flag is used at launch.

### TODO

- [X] Show ATC on map
- [X] Show flight path trace
  - [X] Show multiple trace at the same time
- [X] Dynamic refresh rate
- [X] Dark mode on map
- [X] Show flight status on Discord
  - [X] Bot command !finfo
- [X] Colors for connection states
- [X] Teleport aircraft using map
- [X] x64 SimConnect from MSFS
- [X] Setting for minimize to Task bar
- [X] Stopwatch & leaderboard for race event
- [ ] Race events
  - [ ] Stream overlay
- [ ] Dashboard
- [ ] Private group
- [ ] Flight plan database for ATC
- [ ] Search airport on map
- [ ] MSIX packaging
- [ ] Gamebar integration
- [ ] Gradient for altitude
- [ ] 3D terrain