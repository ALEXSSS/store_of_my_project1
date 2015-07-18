package com.example.alex.try3;


import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.os.Bundle;
import android.app.Activity;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class SettingsActivity extends Activity {

    Button btnSave;
    Button btnClr;
    Button btnGps;
    SharedPreferences sPref;
    EditText Etext;
    final String SAVED_TEXT = "saved_text";
    Context ctx=this;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        //буду записывать в ту же базу
        super.onCreate(savedInstanceState);
        setContentView(R.layout.my_settings);
        DBHelper db=new DBHelper(this);
        final SQLiteDatabase db1=db.getWritableDatabase();

        btnSave = (Button) findViewById(R.id.buttonSave);
        btnGps=(Button) findViewById(R.id.buttonGps);
        btnClr=(Button) findViewById(R.id.buttonCLR);
        Etext=(EditText) findViewById(R.id.editText2);
        //btnSave.setOnClickListener(oclBtnCancel);
        btnClr.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                try{
                    db1.execSQL("DELETE FROM photo");
                    Toast.makeText(ctx,"настройки обнулены",Toast.LENGTH_SHORT).show();
                }
                catch (Exception e)
                {
                    Log.d("MyLogs","db is broken");
                }
            }
        });;
        btnGps.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    Intent intent = new Intent();
                    intent.setAction(Intent.ACTION_VIEW);
                    intent.setData(Uri.parse("geo:55.754283,37.62002"));
                    startActivity(intent);
                }
                catch (Exception e)
                {
                    Toast.makeText(ctx,"Карты не найдены",Toast.LENGTH_SHORT).show();
                }
            }
        });
        btnSave.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                /*Cursor c = db1.query("photo", null, null, null, null, null, null);

                    if (c.moveToFirst()) {
                        int indexForPhoto = c.getColumnIndex("id");
                        do {
                            //Log.d("MyLogsF", "id= "+c.getString(indexForPhoto));
                            Log.d("MyChek", "id= "+c.getString(indexForPhoto));

                        }
                        while (c.moveToNext());
                    }*/
                switch (v.getId()) {
                    case R.id.buttonSave:
                        //saveText();
                        int value=MyFindByIdSettings(db1);
                       Log.d("MyChek","value= "+value);
                        try {
                                if(value==0)
                                {
                                    db1.execSQL("DELETE FROM photo  WHERE id ='sctt'");
                                    db1.execSQL("insert into 'photo' ('id') values ('sctt" + Etext.getText() + "')");
                                    //db1.execSQL("DELETE FROM photo  WHERE id = sett-1");
                                }
                                else
                                {
                                    db1.execSQL("DELETE FROM photo  WHERE id ='sctt" + value + "'");
                                    db1.execSQL("insert into 'photo' ('id') values ('sctt" + Etext.getText() + "')");
                                }
                            Toast.makeText(ctx,"saved "+Etext.getText(),Toast.LENGTH_SHORT).show();
                                }
                        catch (Exception e)
                        {
                            //Log.d("MyLogs",e.toString());
                        }
                        //db1.close();
                        //c.close();
                        break;
                    default:
                        break;
                }
            }
        });
    }
   /* OnClickListener oclBtnCancel = new OnClickListener() {
        @Override
        public void onClick(View v) {
            // Меняем текст в TextView (tvOut)
            switch (v.getId()) {
                case R.id.buttonSave:
                    //saveText();

                    break;
  	    case R.id.btnLoad:
  	      loadText();
  	      break;
                default:
                    break;
            }
        }
    };*/

   /* не работают корректно в иных активити
   void saveText() {
        sPref = getPreferences(MODE_MULTI_PROCESS);
        if(Integer.valueOf(Etext.getText().toString())<60) {
            Editor ed = sPref.edit();
            ed.putString(SAVED_TEXT, Etext.getText().toString());
            ed.commit();
            Toast.makeText(this, "Text saved", Toast.LENGTH_LONG).show();
        }
        else {
            Toast.makeText(this, "Sorry", Toast.LENGTH_SHORT).show();
            Toast.makeText(this, "Text didn't save because your textsize is very big", Toast.LENGTH_LONG).show();
        }
    }
   public String loadText() {
        sPref = getPreferences(MODE_MULTI_PROCESS);
        String savedText=sPref.getString(SAVED_TEXT,"");
        Toast.makeText(this, "Setting loaded", Toast.LENGTH_LONG).show();
        return savedText;
    }*/
   public int MyFindByIdSettings(SQLiteDatabase db1)
   {
       Cursor c = db1.query("photo", null, null, null, null, null, null);
       try {
           if (c.moveToFirst()) {
               int indexForPhoto = c.getColumnIndex("id");
               do {

                   //Log.d("MyLogsf", "id= " + c.getString(indexForPhoto)+"setting");
                   //Log.d("MyChek","id="+c.getString(indexForPhoto));
                   if (c.getString(indexForPhoto).indexOf("sctt")!=-1)
                   {
                       Log.d("MyChek","ids="+c.getString(indexForPhoto));
                       String str_setting=c.getString(indexForPhoto);
                       str_setting=str_setting.replace("sctt","");
                       int value_sett;
                       try
                       {
                           Log.d("MyChek","inside while"+str_setting);
                           value_sett = Integer.valueOf(str_setting);
                           if(value_sett==1942) return 1942;
                       }
                       catch (Exception e)
                       {
                           value_sett=0;
                           Log.d("MyChek","Exception");
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
           Log.d("MyChek","return 1942 2");
           return 1942;
       }
       catch (Exception e)
       {
           Log.d("MyChek", "!!!!Exception на Select");
           return 1942;
       }
       finally
       {
           c.close();
           Log.d("MyLogs", "проверка на повторения окончена!");
       }
   }
}
