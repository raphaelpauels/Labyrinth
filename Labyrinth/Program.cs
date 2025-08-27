
using Labyrinth;

LabyrinthBuilder builder = new();
builder["test"] = new LabyrinthModel();
builder["test"].Nom = "Test";

string layout = builder.model1;

LabyrinthModel model = new();
model.Nom = layout;

LabyrinthVue vue = new();
vue.Affiche(model, "loaded succesfully");

Controller controller = new();

controller.Start();