using System;
using System.Threading;

namespace HelpLone
{
    public class Program
    {
        static void Main(string[] args)
        {
            Barbarian barbarian = new Barbarian();
            barbarian.Heal();
            barbarian.Slash();
            barbarian.Die();

            Wizard wizard = new Wizard();
            wizard.Fight();
            wizard.Teleport(2, 5);
            wizard.Die();

            Witch witch = new Witch();
            witch.Fight();
            witch.Teleport(2, 5);
            witch.RaiseShield();

            Knight knight = new Knight();
            knight.Fight();
            knight.RaiseShield();
            knight.Die();
        }
    }
}