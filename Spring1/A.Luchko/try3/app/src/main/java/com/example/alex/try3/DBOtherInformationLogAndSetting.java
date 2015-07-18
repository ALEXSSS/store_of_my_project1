
package com.example.alex.try3;

//это пустой класс и он пока не нужен
//идея для которой он реализовался пока не нужна
        import android.content.Context;
        import android.database.sqlite.SQLiteDatabase;
        import android.database.sqlite.SQLiteOpenHelper;
        import android.util.Log;

public class DBOtherInformationLogAndSetting extends SQLiteOpenHelper
{
    public DBOtherInformationLogAndSetting(Context context) {
        super(context, "DBOtherInformationLogAndSetting", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db)
    {
        Log.d("MyLogs", "OnCreateDB");
        db.execSQL("create table settings("
                +"id int primary key" +
                "settings_value int" +
                ");");
    }



    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
    {
    }
}