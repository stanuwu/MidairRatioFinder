//Midair Ration finder by jesus

using System.Diagnostics;
using System.Text;
using MidairRatioFinder;

Console.Title = "Midair Ratio Finder by jesus";
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Configure Barrel");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Velocity: ");
Console.ResetColor();
string velocity = Console.ReadLine();
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Position: ");
Console.ResetColor();
string position = Console.ReadLine();
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Power: ");
Console.ResetColor();
int rpower = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Direction (x, z): ");
Console.ResetColor();
bool dir_x = !(Console.ReadLine().ToLower() == "z");
Console.ForegroundColor = ConsoleColor.Green;

string[] vel3 = velocity.Split(" ");
string[] pos3 = position.Split(" ");

double rvel_x = Convert.ToDouble(vel3[dir_x ? 0 : 2]);
double rvel_y = Convert.ToDouble(vel3[1]);
double rpos_x = Convert.ToDouble(pos3[dir_x ? 0 : 2]);
double rpos_y = Convert.ToDouble(pos3[1]);

Console.WriteLine("Calculating Barrel...");
double avel_x = rvel_x / rpower;
double avel_y = rvel_y / rpower;
double ali_x = rpos_x - Math.Floor(rpos_x);
double ali_y = rpos_y - Math.Floor(rpos_y);

Console.WriteLine("");
Console.WriteLine("Configure Ratio Finder");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Max Gameticks: ");
Console.ResetColor();
int max_gt = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Min Power: ");
Console.ResetColor();
int min_power = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Max Power: ");
Console.ResetColor();
int max_power = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Min Distance: ");
Console.ResetColor();
int min_x = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Max Distance: ");
Console.ResetColor();
int max_x = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Min Height: ");
Console.ResetColor();
int min_y = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("Max Height: ");
Console.ResetColor();
int max_y = Convert.ToInt32(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Green;

Console.WriteLine("Finding Ratio...");
List<Ratio> ratios = new List<Ratio>();
for (int power = min_power; power <= max_power; power++)
{
    double pos_x = ali_x;
    double pos_y = ali_y;
    double vel_x = avel_x * power;
    double vel_y = avel_y * power;
    for (int gt = 1; gt <= max_gt; gt++)
    {
        vel_y -= 0.04;
        pos_x += vel_x;
        pos_y += vel_y;
        vel_y *= 0.98;
        vel_x *= 0.98;
        
        if (pos_x > max_x || pos_y > max_y) break;
        double norm_pos = pos_x - Math.Floor(pos_x);
        if (norm_pos >= 0.48 && norm_pos <= 0.52)
        {
            if (pos_x >= min_x && pos_y >= min_y)
            {
                ratios.Add(new Ratio(power, gt, pos_x, pos_y));
            }
        }
    }
}
Console.WriteLine();
Console.WriteLine($"{ratios.Count} Ratios Found!");
Console.WriteLine("Saving!");

StreamWriter streamWriter = new StreamWriter("./ratios.txt");
foreach (Ratio r in ratios)
{
    double dist_x = Math.Round(r.X, 3);
    double dist_y = Math.Round(r.Y, 3);
    double fpos_x = Math.Round(r.X + Math.Floor(rpos_x), 3);
    double fpos_y = Math.Round(r.Y + Math.Floor(rpos_y), 3);
    StringBuilder line = new StringBuilder();
    line.Append($"Power: {r.Power}".PadRight(15, ' '));
    line.Append($"Gametick: {r.Gametick}".PadRight(17, ' '));
    line.Append($"Distance: ({dist_x}, {dist_y})".PadRight(34, ' '));
    line.Append($"Position: ({fpos_x}, {fpos_y})");
    streamWriter.WriteLine(line.ToString());
}
streamWriter.Close();
Process.Start("notepad.exe", "./ratios.txt");

Console.ReadKey();