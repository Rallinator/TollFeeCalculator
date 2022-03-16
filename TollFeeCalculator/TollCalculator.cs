using System;
using System.Globalization;
using TollFeeCalculator;

public class TollCalculator
{
	public const long TicksPerMinute = 600000000;

	private List<(DateTime start, DateTime end, int cost)> TimeAndPrice = new List<(DateTime start, DateTime end, int cost)>
	{
		(new DateTime(2022, 1, 1, 0, 0, 0), new DateTime(2022, 1, 1, 5, 59, 0), 0),
		(new DateTime(2022, 1, 1, 6, 0, 0), new DateTime(2022, 1, 1, 6, 29, 0), 8),
		(new DateTime(2022, 1, 1, 6, 30, 0), new DateTime(2022, 1, 1, 6, 59, 0), 13),
		(new DateTime(2022, 1, 1, 7, 0, 0), new DateTime(2022, 1, 1, 7, 59, 0), 18),
		(new DateTime(2022, 1, 1, 8, 0, 0), new DateTime(2022, 1, 1, 8, 29, 0), 13),
		(new DateTime(2022, 1, 1, 8, 30, 0), new DateTime(2022, 1, 1, 14, 59, 0), 8),
		(new DateTime(2022, 1, 1, 15, 0, 0), new DateTime(2022, 1, 1, 15, 29, 0), 13),
		(new DateTime(2022, 1, 1, 15, 30, 0), new DateTime(2022, 1, 1, 16, 59, 0), 18),
		(new DateTime(2022, 1, 1, 17, 0, 0), new DateTime(2022, 1, 1, 17, 59, 0), 13),
		(new DateTime(2022, 1, 1, 18, 0, 0), new DateTime(2022, 1, 1, 18, 29, 0), 8),
		(new DateTime(2022, 1, 1, 18, 30, 0), new DateTime(2022, 1, 1, 23, 59, 0), 0),
	};

	/**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

	public int GetTollFee(VehicleType vehicle, List<DateTime> dates)
	{
		DateTime intervalStart = dates[0];
		int totalFee = 0;
		foreach (DateTime date in dates)
		{
			int nextFee = GetTollFee(date, vehicle);
			int tempFee = GetTollFee(intervalStart, vehicle);

			long diffInTicks = date.Ticks - intervalStart.Ticks;
			long minutes = diffInTicks / TicksPerMinute;

			if (minutes <= 60)
			{
				if (totalFee > 0) totalFee -= tempFee;
				if (nextFee >= tempFee) tempFee = nextFee;
				totalFee += tempFee;
			}
			else
			{
				totalFee += nextFee;
			}
		}
		if (totalFee > 60) totalFee = 60;
		return totalFee;
	}

	private bool IsTollFreeVehicle(VehicleType vehicle)
	{
		return (int)vehicle < 100;
	}

	public int GetTollFee(DateTime date, VehicleType vehicle)
	{
		if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

		DateTime calculationTime = new DateTime(2022, 1, 1, date.Hour, date.Minute, 0);

		foreach (var time in TimeAndPrice)
		{
			if (time.start <= calculationTime && calculationTime <= time.end)
				return time.cost;
		}
		return 0;
	}

	private bool IsTollFreeDate(DateTime date)
	{
		int year = date.Year;
		int month = date.Month;
		int day = date.Day;

		if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

		DateTime easterSunday = EasterSunday(year);

		if (month == 1 && day == 1 ||
			   month == 4 && day == 30 ||
			   month == 5 && day == 1 ||
			   month == 6 && (day == 5 || day == 6 || (19 <= day && day <= 25 && date.DayOfWeek == DayOfWeek.Friday)) ||
			   month == 7 ||
			   month == 10 && (day == 29 || day == 30) && date.DayOfWeek == DayOfWeek.Friday ||
			   month == 11 && (1 <= day && day <= 5 && date.DayOfWeek == DayOfWeek.Friday) ||
			   month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
		{
			return true;
		}
		else if(date.Month == easterSunday.AddDays(-3).Month && date.Day == easterSunday.AddDays(-3).Day ||
			date.Month == easterSunday.AddDays(-2).Month && date.Day == easterSunday.AddDays(-2).Day ||
			date.Month == easterSunday.AddDays(1).Month && date.Day == easterSunday.AddDays(1).Day ||
			date.Month == easterSunday.AddDays(39).Month && date.Day == easterSunday.AddDays(39).Day ||
			date.Month == easterSunday.AddDays(40).Month && date.Day == easterSunday.AddDays(40).Day)
		{
			return true;
		}

		
		

		return false;
	}

	//Definetly not stolen from here https://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year
	public static DateTime EasterSunday(int year)
	{
		int day = 0;
		int month = 0;

		int g = year % 19;
		int c = year / 100;
		int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
		int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

		day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
		month = 3;

		if (day > 31)
		{
			month++;
			day -= 31;
		}

		return new DateTime(year, month, day);
	}
}