using System;
using OpenNLP.Tools.Chunker;
using OpenNLP.Tools.PosTagger;
using OpenNLP.Tools.SentenceDetect;
using OpenNLP.Tools.Tokenize;
using SharpEntropy.IO;
using Xunit;

namespace Trainer.Tests
{
    public class FirstUnitTest
    {
        [Fact]
        public void FirstTests()
        {
            // The file with the training samples; works also with an array of files
            var trainingFile = "path/to/training/file";
            // The number of iterations; no general rule for finding the best value, just try several!
            var iterations = 5;
            // The cut; no general rule for finding the best value, just try several!
            var cut = 2;
            // The characters which can mark an end of sentence
            var endOfSentenceScanner = new CharactersSpecificEndOfSentenceScanner('.', '?', '!', '"', '-', '…');
            // Train the model (can take some time depending on your training file size)
            var model = MaximumEntropySentenceDetector.TrainModel(trainingFile, iterations, cut, endOfSentenceScanner);
            
            // Persist the model to use it later
            var outputFilePath = "path/to/persisted/model";
            new BinaryGisModelWriter().Persist(model, outputFilePath);
        }
    }
}
