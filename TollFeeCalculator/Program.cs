using TollFeeCalculator;

bool run = true;

TestExamples testExamples = new TestExamples();
TollCalculator tollCalculator = new TollCalculator();

while (run)
{
	Console.WriteLine("What test example to use? 1 - {0}", testExamples.Examples.Count);
	string test = Console.ReadLine();
	int chosenTest;

	int.TryParse(test, out chosenTest);

	if (chosenTest != 0)
	{
		Example chosenExample = testExamples.Examples[chosenTest - 1];
		int tollFee = tollCalculator.GetTollFee(chosenExample.Vehicle, chosenExample.PassageTimes);

		Console.WriteLine("Total toll fee is {0}", tollFee);
	}
	else
	{
		Console.WriteLine("Not a number between 1 - {0}", testExamples.Examples.Count);
	}

	Console.WriteLine("Do you want to continue? [y] [n]");
	if (Console.ReadLine() == "n")
		run = false;

}