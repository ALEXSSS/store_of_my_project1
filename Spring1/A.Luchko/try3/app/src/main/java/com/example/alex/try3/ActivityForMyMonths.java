package com.example.alex.try3;

import java.util.ArrayList;
import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ListView;
import android.widget.Toast;


public class ActivityForMyMonths extends Activity
{
MonthsInfo1942 monthInfo=new MonthsInfo1942();
    ArrayList<Product> products = new ArrayList<Product>();
    BoxAdapter boxAdapter;
    String month_num_byString;
    /** Called when the activity is first created. */
    public void onCreate(Bundle savedInstanceState) {
        month_num_byString= getIntent().getStringExtra("month");
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main1);
        // создаем адаптер
        fillData();
        boxAdapter = new BoxAdapter(this, products,savedInstanceState);
        // настраиваем список
        ListView lvMain = (ListView) findViewById(R.id.lvMain);
        lvMain.setAdapter(boxAdapter);
    }

    // генерируем данные для адаптера
    void fillData()
    {
        int monthByint=Integer.parseInt(month_num_byString)+1;
        Month month=monthInfo.year[Integer.parseInt(month_num_byString)];
//int num_of_day_this=month_num_byString
        for (int i = 1; i <= month.num_days; i++)
        {
            String str=monthInfo.ShowWeeksDaysByString(month,i);
            str+=" "+"\n"+monthInfo.ShowYearDays(month,i)+" день года";
            products.add(new Product(month.name+" "+i, str,"d"+i+"m"+monthByint+"y"+1942,
                    R.drawable.mainp, false));
        }
    }

    // выводим информацию
    public void showResult(View v) {
        try {
            String result = "Грузим ";

            for (Product p : boxAdapter.getBox()) {
                ImageFind imgfind = new ImageFind();
                if (p.box) {
                    result += "\n" + p.name ;
                    imgfind.SendImageForSearch(this, p.date);
                    Log.d("Pdate", p.date);
                }
            }
            Toast.makeText(this, result, Toast.LENGTH_LONG).show();
        }
        catch (Exception e)
        {

        }
    }
}
