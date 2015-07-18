package com.example.alex.try3;


import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.util.Log;

public class DBHelper extends SQLiteOpenHelper
{
    public DBHelper(Context context) {
        super(context, "MyDB", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {
        Log.d("MyLogs","OnCreateDB");
        db.execSQL("create table photo("
                +"id varchar(12) primary key);");
    }



    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
    }
}