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

using System.Threading;
using SendInputsDemo;

namespace Chessnt
{
    public class VoiceCommand : State
    {
        private TileHelper tileHelper;
        private int x;
        private int y;
        public VoiceCommand(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
          : base(game, graphicsDevice, content)
        {
            tileHelper = new TileHelper();
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
                    game.ChangeState(new RuleState(game, graphicsDevice, content));
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
            Dictionary<string, TileCoordinate> tileHelpers = new Dictionary<string, TileCoordinate>();

            for (char c = 'A'; c <= 'H'; c++)
            {
                for (int i = 1; i <= 8; i++)
                {
                    string key = c.ToString() + i.ToString() + ".";
                    TileCoordinate tileHelperObj = null;

                    switch (c)
                    {
                        case 'A':
                            switch (i)
                            {
                                case 1:
                                    tileHelperObj = tileHelper.a1;
                                    break;
                                case 2:
                                    tileHelperObj = tileHelper.a2;
                                    break;
                                case 3:
                                    tileHelperObj = tileHelper.a3;
                                    break;
                                case 4:
                                    tileHelperObj = tileHelper.a4;
                                    break;
                                case 5:
                                    tileHelperObj = tileHelper.a5;
                                    break;
                                case 6:
                                    tileHelperObj = tileHelper.a6;
                                    break;
                                case 7:
                                    tileHelperObj = tileHelper.a7;
                                    break;
                                case 8:
                                    tileHelperObj = tileHelper.a8;
                                    break;
                            }
                            break;
                        case 'B':
                            switch (i)
                            {
                                case 1:
                                    tileHelperObj = tileHelper.b1;
                                    break;
                                case 2:
                                    tileHelperObj = tileHelper.b2;
                                    break;
                                case 3:
                                    tileHelperObj = tileHelper.b3;
                                    break;
                                case 4:
                                    tileHelperObj = tileHelper.b4;
                                    break;
                                case 5:
                                    tileHelperObj = tileHelper.b5;
                                    break;
                                case 6:
                                    tileHelperObj = tileHelper.b6;
                                    break;
                                case 7:
                                    tileHelperObj = tileHelper.b7;
                                    break;
                                case 8:
                                    tileHelperObj = tileHelper.b8;
                                    break;
                            }
                            break;
                        case 'C':
                            switch (i)
                            {
                                case 1:
                                    tileHelperObj = tileHelper.c1;
                                    break;
                                case 2:
                                    tileHelperObj = tileHelper.c2;
                                    break;
                                case 3:
                                    tileHelperObj = tileHelper.c3;
                                    break;
                                case 4:
                                    tileHelperObj = tileHelper.c4;
                                    break;
                                case 5:
                                    tileHelperObj = tileHelper.c5;
                                    break;
                                case 6:
                                    tileHelperObj = tileHelper.c6;
                                    break;
                                case 7:
                                    tileHelperObj = tileHelper.c7;
                                    break;
                                case 8:
                                    tileHelperObj = tileHelper.c8;
                                    break;
                            }
                            break;
                        case 'D':
                            switch (i)
                            {
                                case 1:
                                    tileHelperObj = tileHelper.d1;
                                    break;
                                case 2:
                                    tileHelperObj = tileHelper.d2;
                                    break;
                                case 3:
                                    tileHelperObj = tileHelper.d3;
                                    break;
                                case 4:
                                    tileHelperObj = tileHelper.d4;
                                    break;
                                case 5:
                                    tileHelperObj = tileHelper.d5;
                                    break;
                                case 6:
                                    tileHelperObj = tileHelper.d6;
                                    break;
                                case 7:
                                    tileHelperObj = tileHelper.d7;
                                    break;
                                case 8:
                                    tileHelperObj = tileHelper.d8;
                                    break;
                            }
                            break;
                        case 'E':
                            switch (i)
                            {
                                case 1:
                                    tileHelperObj = tileHelper.e1;
                                    break;
                                case 2:
                                    tileHelperObj = tileHelper.e2;
                                    break;
                                case 3:
                                    tileHelperObj = tileHelper.e3;
                                    break;
                                case 4:
                                    tileHelperObj = tileHelper.e4;
                                    break;
                                case 5:
                                    tileHelperObj = tileHelper.e5;
                                    break;
                                case 6:
                                    tileHelperObj = tileHelper.e6;
                                    break;
                                case 7:
                                    tileHelperObj = tileHelper.e7;
                                    break;
                                case 8:
                                    tileHelperObj = tileHelper.e8;
                                    break;
                            }
                            break;
                        case 'F':
                            switch (i)
                            {
                                case 1:
                                    tileHelperObj = tileHelper.f1;
                                    break;
                                case 2:
                                    tileHelperObj = tileHelper.f2;
                                    break;
                                case 3:
                                    tileHelperObj = tileHelper.f3;
                                    break;
                                case 4:
                                    tileHelperObj = tileHelper.f4;
                                    break;
                                case 5:
                                    tileHelperObj = tileHelper.f5;
                                    break;
                                case 6:
                                    tileHelperObj = tileHelper.f6;
                                    break;
                                case 7:
                                    tileHelperObj = tileHelper.f7;
                                    break;
                                case 8:
                                    tileHelperObj = tileHelper.f8;
                                    break;
                            }
                            break;
                        case 'G':
                            switch (i)
                            {
                                case 1:
                                    tileHelperObj = tileHelper.g1;
                                    break;
                                case 2:
                                    tileHelperObj = tileHelper.g2;
                                    break;
                                case 3:
                                    tileHelperObj = tileHelper.g3;
                                    break;
                                case 4:
                                    tileHelperObj = tileHelper.g4;
                                    break;
                                case 5:
                                    tileHelperObj = tileHelper.g5;
                                    break;
                                case 6:
                                    tileHelperObj = tileHelper.g6;
                                    break;
                                case 7:
                                    tileHelperObj = tileHelper.g7;
                                    break;
                                case 8:
                                    tileHelperObj = tileHelper.g8;
                                    break;
                            }
                            break;
                        case 'H':
                            switch (i)
                            {
                                case 1:
                                    tileHelperObj = tileHelper.h1;
                                    break;
                                case 2:
                                    tileHelperObj = tileHelper.h2;
                                    break;
                                case 3:
                                    tileHelperObj = tileHelper.h3;
                                    break;
                                case 4:
                                    tileHelperObj = tileHelper.h4;
                                    break;
                                case 5:
                                    tileHelperObj = tileHelper.h5;
                                    break;
                                case 6:
                                    tileHelperObj = tileHelper.h6;
                                    break;
                                case 7:
                                    tileHelperObj = tileHelper.h7;
                                    break;
                                case 8:
                                    tileHelperObj = tileHelper.h8;
                                    break;
                            }
                            break;
                        default:
                            throw new ArgumentException("Invalid value for c");
                    }
                    tileHelpers.Add(key, tileHelperObj);
                }
            }
            if (tileHelpers.ContainsKey(result.Text))
            {
                TileCoordinate tileHelperObj = tileHelpers[result.Text];
                x = tileHelperObj.GetX();
                y = tileHelperObj.GetY();
            }

            InputSender.SetCursorPosition(x, y);

            ThreadMouseClick();
        }

        private Thread ThreadMouseClick()
        {
            Thread thread = new Thread(new ThreadStart(VeryMouseClick));
            thread.Start();
            return thread;
        }

        private void VeryMouseClick()
        {
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
