using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    internal class LabyrinthVue
    {
        public string Message => "loaded succesfully!";
        public void Print(LabyrinthModel model)
        {
            //Console.Clear();
            // Ich möcht das Grid drucken. Beim Einlesen des Grids aus dem File habe ich Leerzeichen jedoch übersprungen.
            // Deshalb muss ich nun zählen was die max Dimensionen meines Grids sind um fehlende Position mit Leerzeichen zu füllen.
            int maxLine = 0;
            int maxColumn = 0;
            foreach (var entry in model)
            {
                if (entry.Key.Line > maxLine) { maxLine = entry.Key.Line; }
                ;
                if (entry.Key.Column > maxColumn) { maxColumn = entry.Key.Column; }
                ;
            }

            // Anschlissend gehe ich meine Kollektion durch und schaue ob ich für jede Lig/Col Kombination ein Symbol gespeochert habe.
            // Falls nicht, drucke ich ein Leerzeichen. Wenn ich meinen maximale Kolonnenindex erreicht habe, wechsle ich die Linie.
            // Dies mache ich, bis ich die maximale Linie erreicht habe.
            for (int lig = 0; lig <= maxLine; lig++)
            {
                for (int col = 0; col <= maxColumn; col++)
                {
                    if (model.TryGetValue(new PositionLabyrinth(lig, col), out var element))
                        Console.Write(element.Symbole);
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            foreach (var entry in model.PersonnagesMap)
            {
                if (model.PersonnageKey[model.PersonnageActif] == entry.Key)
                {
                    Console.WriteLine($"ACTIF {entry.Key}: Keys: {entry.Value.Bag.Count}");
                }else Console.WriteLine($"{entry.Key}: Keys: {entry.Value.Bag.Count}");
            }
            Console.WriteLine();

        }

    }
}
