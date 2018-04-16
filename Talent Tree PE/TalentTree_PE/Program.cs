using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentTree_PE
{
    class Program
    {
        static void Main(string[] args)
        {
            #region instantiate classes
            //Level 1
            TalentTreeNode Swordsman = new TalentTreeNode("Swordsman", true, null, null);

            //Level 2
            TalentTreeNode Fighter = new TalentTreeNode("Fighter", true, null, null);
            TalentTreeNode Rouge = new TalentTreeNode("Rouge", true, null, null);

            //Level 3 Left
            TalentTreeNode Knight = new TalentTreeNode("Knight", false, null, null);
            TalentTreeNode Barbarian = new TalentTreeNode("Barbarian", false, null, null);

            //Level 3 Right
            TalentTreeNode Theif = new TalentTreeNode("Theif", true, null, null);
            TalentTreeNode Assassin = new TalentTreeNode("Assassin", false, null, null);
            #endregion

            #region set nodes
            //set nodes for swordsman
            Swordsman.LeftNode = Fighter;
            Swordsman.RightNode = Rouge;

            //set nodes for Fighter
            Fighter.LeftNode = Knight;
            Fighter.RightNode = Barbarian;

            //set nodes for Rouge
            Rouge.LeftNode = Theif;
            Rouge.RightNode = Assassin;
            #endregion

            #region calling each class
            //list all classes
            Console.WriteLine("All Classes: ");
            Swordsman.ListAllClasses();

            //list known classes
            Console.WriteLine();
            Console.WriteLine("All Learned Classes: ");
            Swordsman.ListKnownClasses();

            //list next classes in line
            Console.WriteLine();
            Console.WriteLine("Possible Classes: ");
            Swordsman.ListPossibleClasses();
            #endregion
        }
    }
}
