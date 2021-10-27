using System;
using System.Data;
using System.Text;
using rules;
using AsciiTableGenerators;
using crypt;

namespace view
{
    public static class View
    {
        private static StringBuilder tableRules;
        public static void showMenu(string[] strs, RandomCrypt hmac)
        {
            Console.WriteLine("HMAC:");
            Console.WriteLine(BitConverter.ToString(hmac.HMAC.Hash).Replace("-", string.Empty));
            for (int i = 0; i < strs.Length; ++i)
            {
                Console.WriteLine($"{i + 1} - {strs[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        static View()
        {
            DataTable table = new DataTable("Mytable");
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Combinations";
            table.Columns.Add(column);
            

            foreach (var comb in Rules.Combs.Keys)
            {
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = comb;
                table.Columns.Add(column);
            }

            foreach (var comb in Rules.Combs.Keys)
            {
                DataRow row = table.NewRow();
                row["Combinations"] = comb;
                table.Rows.Add(row);
                for (int i = 0; i < Rules.Combs[comb].Length; ++i)
                {
                    switch (Rules.Combs[comb][i])
                    {
                        case Conditions.draw:
                            {
                                row[i + 1] = "draw";
                                break;
                            }
                        case Conditions.lose:
                            {
                                row[i + 1] = "lose";
                                break;
                            }
                        case Conditions.win:
                            {
                                row[i  + 1] = "win";
                                break;
                            }

                    }
                }
                
            }

            tableRules = AsciiTableGenerator.CreateAsciiTableFromDataTable(table);
        }
        public static void showTable()
        {
            Console.WriteLine(tableRules);
        }

        public static void showResult(string userMove, string computerMove, string result, RandomCrypt hmac)
        {
            Console.WriteLine($"Your move: {userMove}");
            Console.WriteLine($"Computer move: {computerMove}");
            Console.WriteLine(result);
            Console.WriteLine($"HMAC key: {BitConverter.ToString(hmac.HMAC.Key).Replace("-", string.Empty)}");
        }
    }
}
