using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using libsvm;

namespace SVMPredict
{
    class Program
    {
        // Using libsvm library from Nicolas Panel https://github.com/nicolaspanel/libsvm.net
        // Currently unsupported

        // from Grid search Lexie's 982 C = 2.0 g =  0.001953125 rate= 67.2098
        static double C = 2.0;
        static double gamma = 0.001953125;

        static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                Console.WriteLine("Usage: PredictSVM <trainfile> <test file> ");
                System.Environment.Exit(0);
            }

            string trainfile = args[0];
            string testfile = args[1];
            Console.WriteLine("Trainfile = {0}", trainfile);
            Console.WriteLine("testfile = {0}", testfile);
            
                        
            var predfile = ProblemHelper.ReadProblem(testfile);
            var svm = new C_SVC(trainfile, KernelHelper.RadialBasisFunctionKernel(gamma), C);
            var cva = svm.GetCrossValidationAccuracy(5);
            int i = 0;
            int total = 1;
                        
            for ( i = 0; i < predfile.l; i++)
            {
                var x = predfile.x[i]; // x is the ith vector sample
                var expectedValue = predfile.y[i];
                var predictedValue = svm.Predict(x); // Make label prediciton 
                if (predictedValue == expectedValue)
                {
                    total++;
                }
                
            }
            Console.WriteLine("math {0}", 15d / 40d);
            double result = ((double) total /(double) i);
            Console.WriteLine("total samples {0}, Crossvalidation Accuracy {1}%",total, Math.Round(cva*100,2));
            Console.WriteLine("Prediction accuracy = {0}%", Math.Round(result*100,2) );
            
        }
    }
}
