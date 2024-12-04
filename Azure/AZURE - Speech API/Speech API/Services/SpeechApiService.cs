using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Speech_API.Services
{
    public class SpeechApiService : ISpeechApiService
    {
        private readonly string _region;
        private readonly string _apiKey;

        public SpeechApiService(IConfiguration configuration)
        {
            _region = configuration["AzureSpeechService:Region"];
            _apiKey = configuration["AzureSpeechService:Key"];
        }

        public async Task<string> RecognizeSpeechAsync(string audioFilePath)
        {
            var config = SpeechConfig.FromSubscription(_apiKey, _region);
            using var audioInput = AudioConfig.FromWavFileInput(audioFilePath);
            using var recognizer = new SpeechRecognizer(config, audioInput);

            var result = await recognizer.RecognizeOnceAsync();
            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                return result.Text;
            }
            else if (result.Reason == ResultReason.NoMatch)
            {
                return "Speech could not be recognized.";
            }
            else
            {
                throw new Exception($"Speech recognition error: {result.Reason}");
            }
        }
    }
}
