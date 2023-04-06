using Microsoft.CognitiveServices.Speech;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using WindowsInput;
using System.Threading;
using SendInputsDemo;

namespace Chessnt
{
    public class VoiceCommand : State
    {
        private MouseState mouseState;
        public VoiceCommand(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            mouseState = new MouseState();
        }

        public async Task RecognitionWithMicrophoneAsync()
        {

            var config = SpeechConfig.FromSubscription("fa917a71bb6746e3922cb46042fb9361", "eastus");

            // Creates a speech recognizer using microphone as audio input.
            using (var recognizer = new SpeechRecognizer(config))
            {
                // Starts recognizing
                Debug.WriteLine("Say something...");
                var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

                // Checks result.
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    //Actual recognized word
                    Debug.WriteLine(result.Text);
                    //process result.Text

                    this.ProcessRecognition(result);

                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Debug.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Debug.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Debug.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Debug.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Debug.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }
            // </recognitionWithMicrophone>
        }

        private void ProcessRecognition(SpeechRecognitionResult result)
        {
            this.MenuRecognition(result);
            this.OptionRecognition(result);
            this.GameRecognition(result);
        }

        private void MenuRecognition(SpeechRecognitionResult result)
        {
            switch (result.Text)
            {
                case "Play.":
                    game.ChangeState(new GameState(game, graphicsDevice, content));
                    break;

                case "Option.":
                    game.ChangeState(new OptionState(game, graphicsDevice, content));
                    break;

                case "Exit.":
                    game.Exit();
                    break;
            }
        }

        private void OptionRecognition(SpeechRecognitionResult result)
        {
            switch (result.Text)
            {
                case "Menu." or "Save." or "Safe.":
                    game.ChangeState(new MenuState(game, graphicsDevice, content));
                    break;
            }
        }

        private void GameRecognition(SpeechRecognitionResult result)
        {
            switch (result.Text)
            {
                case "8/2." or "A2.":

                    Thread thread = new Thread(new ThreadStart(VeryMouseClick));
                    thread.Start();

                    break;
            }
        }

        private void VeryMouseClick()
        {
            InputSender.SetCursorPosition(595, 940);//a1

            InputSender.SendMouseInput(new InputSender.MouseInput[]
            {
                new InputSender.MouseInput
                {
                    dwFlags = (uint)InputSender.MouseEventF.LeftDown
                }
            });

            Thread.Sleep(500);

            InputSender.SendMouseInput(new InputSender.MouseInput[]
            {
                new InputSender.MouseInput
                {   
                    dwFlags = (uint)InputSender.MouseEventF.LeftUp
                }
            });
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        public override void PostUpdate(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
