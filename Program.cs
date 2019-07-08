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
        static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                Console.WriteLine("Usage: PredictSVM <modelfile> <test file> ");
                System.Environment.Exit(0);
            }

            string modelfile = args[0];
            string testfile = args[1];
            double C = 1;
            C_SVC svm;
            
            var predfile = ProblemHelper.ReadProblem(testfile);
            svm = new C_SVC(modelfile);
            predfile = ProblemHelper.ReadProblem(testfile);

            for (int i = 1; i < predfile.l; i++)
            {
                var x = predfile.x[i]; // I assume that this gets one x vector sample
                var predict = svm.Predict(x);

            }
             
            
            
        }
    }
}
