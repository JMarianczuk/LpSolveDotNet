using System;
using System.Diagnostics;

namespace LpSolveDotNet.Demo
{
    internal class NewConstraintSample
    {
        public static int Test()
        {
            LpSolve.Init();

            return Demo();
        }

        private static int Demo()
        {
            int NumberOfColumns = 2;

            using (var lp = LpSolve.make_lp(0, NumberOfColumns))
            {
                if (lp == null)
                {
                    return 1;
                }

                var wheat = new LpVariable(1);
                var barley = new LpVariable(2);
                var wheatColumn = lp.Columns[1];
                var barleyColumn = lp.Columns[2];
                wheatColumn.Name = "wheat";
                barleyColumn.Name = "barley";

                lp.IsAddRowmode = true;

                if (!lp.AddConstraint(120 * wheat + 210 * barley <= 15000)
                    || !lp.AddConstraint(110 * wheat + 30 * barley <= 4000)
                    || !lp.AddConstraint(wheat + barley <= 75))
                {
                    return 3;
                }

                lp.IsAddRowmode = false;
                if (!lp.SetObjectiveFunction(143 * wheat + 60 * barley))
                {
                    return 4;
                }

                lp.IsMaximize = true;
                lp.WriteLp("model.lp");
                lp.Verbosity = lpsolve_verbosity.IMPORTANT;
                var solution = lp.Solve();
                if (solution.Result != lpsolve_return.OPTIMAL)
                {
                    return 5;
                }
            }

            return 0;
        }
    }
}