﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PusheenTheCats.Sprites;
using System;
using PusheenTheCats.Screens;
using PusheenTheCats.Models;

namespace PusheenTheCats
{
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Screen _currentScreen;
        private Screen _nextScreen;

        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        public void ChangeScreen(Screen screen)
        {
            _nextScreen = screen; 
        }

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;

            ScreenWidth = 1280;
            ScreenHeight = 720;

            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            base.Initialize();

            _nextScreen = new TitleScreen(this, graphics.GraphicsDevice, Content);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            if (_currentScreen != null)
                _currentScreen.LoadContent();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if(_nextScreen != null)
            {
                _currentScreen = _nextScreen;
               _nextScreen = null;
                LoadContent();
            }

            _currentScreen.Update(gameTime);

            ScreenWidth = GraphicsDevice.Viewport.Bounds.Width;
            ScreenHeight = GraphicsDevice.Viewport.Bounds.Height;

            Draw(gameTime, spriteBatch);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
        }

        protected virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            _currentScreen.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
