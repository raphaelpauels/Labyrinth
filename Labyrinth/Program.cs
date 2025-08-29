
using Labyrinth;

LabyrinthBuilder builder = new();

string filePath = "E:\\C#\\Labyrinth\\Labyrinth\\bin\\Debug\\net9.0\\test.laby";
LabyrinthModel model = builder.FileToModel(filePath, "modelLaby");

LabyrinthVue vue = new();

Controller controller = new Controller(model, vue);

controller.Start();

















