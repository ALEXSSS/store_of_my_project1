package com.example.alex.try3;

/**
 * Created by Alex on 08.04.2015.
 */
public class MonthsInfo1942
{
    int first_day_year=4;
    Month[] year;
    Month December;
    Month January;
    Month February;
    Month March;
    Month April;
    Month May;
    Month June;
    Month July;
    Month August;
    Month September;
    Month October;
    Month November;
    public MonthsInfo1942()
    {
        December=new Month(31, "December");
        January=new Month(31, "January");
        February=new Month(28, "February");
        March=new Month(31, "March");
        April=new Month(30, "April");
        May=new Month(31, "May");
        June=new Month(30, "June");
        July=new Month(31, "July");
        August=new Month(31, "August");
        September=new Month(30, "September");
        October=new Month(31, "October");
        November=new Month(30, "November");
        year=new Month[]{January,February, March,April,May,June,July,August,September,October,November,December};
    }
    public int ShowMonthsDays(int i)
    {
        if ((i>=0)&&(i<=12))
            return year[i-1].num_days;
        return 0;
    }
    public int ShowYearDays(Month month, int day_of_month)
    {
        int summ=0;
        for(int i=0; year[i].name!=month.name; i++)
        {
            summ+=year[i].num_days;
            //System.out.println(year[i].name+": "+year[i].num_days+ " ");
            //System.out.println("  "+" +");
        }
        //System.out.println("   = "+summ);
        // System.out.println("   + "+day_of_month);
        for(int i=1; i<=day_of_month;i++)
        {
            summ+=1;
        }
        return summ;
    }
    public int ShowWeeksDays(Month month, int day_of_month)
    {
        if((day_of_month>=0)&&(day_of_month<=month.num_days))
        {
            int day=ShowYearDays(month,day_of_month);
            int day_of_week=(day+first_day_year-1)%7;
            if(day_of_week!=0) return day_of_week;
            return 7;
        }
        else
        {
            return 8;
        }
    }
    public String ShowWeeksDaysByString(Month month, int day_of_month)
    {
        switch (ShowWeeksDays(month, day_of_month))
        {
            case 1: return "Понедельник";
            case 2: return "Вторник";
            case 3: return "Среда";
            case 4: return "Четверг";
            case 5: return "Пятница";
            case 6: return "Суббота";
            case 7: return "Воскресенье";
            default: return "Пятница!!!";
        }
    }
}
