using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using libsvm;
using SVMSupport;

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
                Console.WriteLine("Usage: PredictSVM <trained model> <test file> ");
                System.Environment.Exit(0);
            }

            string modelfile = args[0];
            string testfile = args[1];
            Console.WriteLine("Model File = {0}", modelfile);
            Console.WriteLine("testfile = {0}", testfile);
            
                        
            var predfile = ProblemHelper.ReadProblem(testfile);
            var svm = new C_SVC(modelfile, KernelHelper.RadialBasisFunctionKernel(gamma), C);
            
            var cva = svm.GetCrossValidationAccuracy(5);
            double result = Predictions.PredictTestSet(testfile,svm);
                        
            Console.WriteLine("total samples {0}, Crossvalidation Accuracy {1}%",predfile.l, Math.Round(cva*100,2));
            Console.WriteLine("Prediction accuracy = {0}%", Math.Round(result*100,2) );
            //svm.Export(string model_file_name);
            
        }
    }
}
