using System;
using libsvm;



namespace PredictionRoutines
{
    class Predict 
    {

        static public double Predict_y(string inputfile, C_SVC svm)
        {
            int i;
            double total = 1;
            var predfile = ProblemHelper.ReadProblem(inputfile);
            double expectedValue = 0;

            for (i = 0; i < predfile.l; i++)
            {
                var x = predfile.x[i]; // x is the ith vector sample
                expectedValue = predfile.y[i];
                var predictedValue = svm.Predict(x); // Make label prediciton 
                if (predictedValue == expectedValue) // Compare the predicited with the known value and calculate accruacty
                {
                    total++;
                }

            }
            double result = ((double)total / (double)i);
            return result;
        }
        
    }
}