﻿using PusheenTheCats.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PusheenTheCats.Models
{
    public class MapManager
    {
        protected ContentManager _content;
        protected GameMain _game;
        protected GraphicsDevice _graphicsDevice;

        public MapManager(GameMain game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this._game = game;
            this._content = content;
            this._graphicsDevice = graphicsDevice;
        }

        public List<Platform> CreatePlatforms()
        {
            List<Platform> platforms = new List<Platform>();

            var mainPlatform = _content.Load<Texture2D>("Platforms/mainPlatform");
            var onAirPlatform = _content.Load<Texture2D>("Platforms/onAirPlatform");
            var onAirPlatform2 = _content.Load<Texture2D>("Platforms/onAirPlatform2");

            MainPlatform(platforms, mainPlatform);

            OnAirPlatforms(platforms, onAirPlatform);

            return platforms;
        }

        private void MainPlatform(List<Platform> platforms, Texture2D mainPlatform)
        {
            Platform platform = new Platform(_game, mainPlatform, new Vector2(0, 590));
            platforms.Add(platform);
        }

        private void OnAirPlatforms(List<Platform> platforms, Texture2D onAirPlatform)
        {
            var airPlatform0 = new Platform(_game, onAirPlatform, new Vector2(50, 200)); 
            var airPlatform1 = new Platform(_game, onAirPlatform, new Vector2(500, 200)); 
            var airPlatform2 = new Platform(_game, onAirPlatform, new Vector2(950, 200)); 

            platforms.Add(airPlatform0);
            platforms.Add(airPlatform1);
            platforms.Add(airPlatform2);
        }
    }
}
