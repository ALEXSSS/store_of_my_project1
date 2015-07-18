package com.example.alex.try3;

import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;



public class InfoActivity extends ActionBarActivity
{
    SharedPreferences sPref;
    String date;
    String info;
    final String SAVED_TEXT = "saved_text";
    //String position;
    final String LOG_TAG = "myLogs";
    float size_of_text;
    TextView Tv2;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        date=getIntent().getStringExtra("date");
        Log.d(LOG_TAG, "DATE: " + date);
        setContentView(R.layout.activity_info);
        info=getIntent().getStringExtra("info");
        //position=getIntent().getStringExtra("position");
        //Log.d(LOG_TAG, "INFO: " + info);
        DBHelper db=new DBHelper(this);

        final SQLiteDatabase db1=db.getWritableDatabase();
        Tv2=(TextView) findViewById(R.id.textInfo2);
        int value=MyFindByIdSettings(db1);

        size_of_text = value;
            //Log.d("excString", "1 "+loadText());
        if(size_of_text<6|| size_of_text>45 || size_of_text==0 || size_of_text==1942)
        Tv2.setTextSize(20);
        else
        Tv2.setTextSize(size_of_text);
        //Log.d("TextInfo",String.valueOf(size_of_text)+" "+value);
        //Log.d("TextInfo",String.valueOf(size_of_text)+" "+value);
        ImageView Img=(ImageView) findViewById(R.id.imageViewInfo);
        Boolean B=findDay(date);
        if(B)
        {
            Toast.makeText(this,
                    "Информация имеется", Toast.LENGTH_LONG).show();
        }
        else
        {
            Toast.makeText(this,
                    "Информация не имеется", Toast.LENGTH_LONG).show();
        }
        Resources r = this.getResources();
        if (B)
        {
            //String str="R.raw"+date;
            int strId = getResources().getIdentifier("raw/"+date, "raw", getPackageName());
            int strId1 = getResources().getIdentifier("drawable/"+date, "drawable", getPackageName());
            InputStream is = r.openRawResource(strId);
            String myText = convertStreamToString(is);
            TextView Tv1=(TextView) findViewById(R.id.textViewForTitle);
            Tv1.setText(info);
            Tv2.setText("\n\n" + myText);
            Img.setImageResource(strId1);
        }
        else
        {
            if(!MyFindById(date,db1))
            {
                //Image image=new Image("data//data//com.example.alex.try3//"+date+".jpg") ;
               // Uri uri=new Uri();
                Bitmap bm= BitmapFactory.decodeFile("data//data//com.example.alex.try3//" + date + ".bmp");
                Img.setImageBitmap(bm);
            }
            else
            {
                Img.setImageResource(R.drawable.mainp);
            }
        }
       // Toast.makeText (getApplicationContext(), date , Toast.LENGTH_LONG).show();
    }
    public boolean MyFindById(String str,SQLiteDatabase db1)
    {
        Cursor c = db1.query("photo", null, null, null, null, null, null);
        try {
            if (c.moveToFirst()) {
                int indexForPhoto = c.getColumnIndex("id");
                do {
                    //Log.d("MyLogsF", "id= "+c.getString(indexForPhoto));
                    if (str.equals(c.getString(indexForPhoto))) return false;
                    Log.d("MyLogs", "id= "+c.getString(indexForPhoto));
                }
                while (c.moveToNext());
            }
            //c.close();
            return true;
        }
        catch (Exception e)
        {
            //Log.d("MyLogs", "!!!!Exception на Select");
            return false;
        }
        finally
        {
            c.close();
            //Log.d("MyLogs", "проверка на повторения окончена!");
        }
    }
public boolean findDay(String day)
{
    String[] days = getResources().getStringArray(R.array.daysofyearforcode);
    for(String a: days)
    {
    //Log.d(LOG_TAG, "mass:" + a+ " ? "+day+".");
    if (day.equals(a)) return true;
    }
    return false;
}


    @Override
    public boolean onCreateOptionsMenu(Menu menu)
    {
        getMenuInflater().inflate(R.menu.infotxt, menu);
        return true;
    }

    String  convertStreamToString(InputStream is)
    {
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        int i = 0;
        try {
            i = is.read();

        while( i != -1)
        {
            baos.write(i);
            i = is.read();
        }
        return  baos.toString();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return "";
    }
    public void ChangeOrNext(View v)
    {
        switch (v.getId()){
            case R.id.buttoninfo:
                if(size_of_text<40)
                {
                    size_of_text += 2.5;
                    Tv2.setTextSize(size_of_text);
                    break;
                }
            case R.id.buttoninfo1:
                if(size_of_text>10)
                {
                    size_of_text -= 2.5;
                    Tv2.setTextSize(size_of_text);
                    break;
                }
        }
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        int id = item.getItemId();
        Intent intent;
        if (id == R.id.action_settings) {
            intent = new Intent("Show.Settings12");
            startActivity(intent);
            return true;
        }
        return super.onOptionsItemSelected(item);
    }
    public int MyFindByIdSettings(SQLiteDatabase db1)
    {
        Cursor c = db1.query("photo", null, null, null, null, null, null);
        try {
            if (c.moveToFirst()) {
                int indexForPhoto = c.getColumnIndex("id");
                do {
                    Log.d("MyChek","id="+c.getString(indexForPhoto));
                    if (c.getString(indexForPhoto).indexOf("sctt")!=-1)
                    {
                        //Log.d("MyChek","ids="+c.getString(indexForPhoto));
                        String str_setting=c.getString(indexForPhoto);
                        str_setting=str_setting.replace("sctt","");
                        int value_sett;
                        try
                        {
                            //Log.d("MyChek","inside while"+str_setting);
                            value_sett = Integer.valueOf(str_setting);
                            if(value_sett==1942) return 1942;
                        }
                        catch (Exception e)
                        {
                            value_sett=0;
                            //Log.d("MyChek","Exception");
                        }
                        return value_sett;
                    }
                    //Log.d("MyChek","return 1942");
                    //return 1942;
                    //Log.d("MyLogs", "id= "+c.getString(indexForPhoto));
                }
                while (c.moveToNext());
            }
            //c.close();
            //Log.d("MyChek","return 1942 2");
            return 1942;
        }
        catch (Exception e)
        {
            //Log.d("MyChek", "!!!!Exception на Select");
            return 1942;
        }
        finally
        {
            c.close();
            //Log.d("MyLogs", "проверка на повторения окончена!");
        }
    }

    /*public int loadText() {
        try {
            sPref = getPreferences(MODE_MULTI_PROCESS);
            String savedText = sPref.getString(SAVED_TEXT, "");
            Toast.makeText(this, "Setting loaded " +savedText, Toast.LENGTH_LONG).show();
            //if(!savedText.equals(""))
            return Integer.valueOf(savedText);
            //else
                //return 33;
        }
        catch (Exception e)
        {
            Log.d("MyLogs",e.toString()+"!!!!!");
            return 33;
        }
    }*/
}
