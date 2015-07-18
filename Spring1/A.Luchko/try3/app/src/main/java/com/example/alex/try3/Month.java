package com.example.alex.try3;

/**
 * Created by Alex on 11.04.2015.
 */
/* Для информации
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
*/
class Month
{
    int num_days;
    String name;
    public Month(int num_days, String name)
    {
        this.num_days=num_days;
        this.name=name;
    }
}