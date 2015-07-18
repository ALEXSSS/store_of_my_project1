package com.example.alex.try3;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.Toast;

import static android.support.v4.app.ActivityCompat.startActivity;


public class MainActivity extends ActionBarActivity {

    final String LOG_TAG = "myLogs";

    ListView lvMain;
    MonthsInfo1942 month=new MonthsInfo1942();
    /** Called when the activity is first created. */
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.first_scr);
        ImageView imv = (ImageView) findViewById(R.id.iconFirst);
        imv.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                newScreen();
            }
        });
    }
    void newScreen()
    {
        setContentView(R.layout.main);
        ImageFind gf=new ImageFind();
        lvMain = (ListView) findViewById(R.id.lvMain);

        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(
                this, R.array.names, R.layout.list_item);
        lvMain.setAdapter(adapter);

        lvMain.setOnItemClickListener(new OnItemClickListener() {
            public void onItemClick(AdapterView<?> parent, View view,
                                    int position, long id) {
                Log.d(LOG_TAG, "itemClick: position = " + position + ", id = "
                        + id);
                Intent intent = new Intent("Show.activity.MyApp");
                intent.putExtra("month",Integer.toString(position));
                startActivity(intent);

            }
        });

        lvMain.setOnItemSelectedListener(new OnItemSelectedListener() {
                public void onItemSelected(AdapterView<?> parent, View view,
                int position, long id) {
                    Log.d(LOG_TAG, "itemSelect: position = " + position + ", id = "
                            + id);
                    Intent intent = new Intent("Show.activity.MyApp");
                    //Intent intent = new Intent(this, ActivityForMyMonths.class);
                    intent.putExtra("month",Integer.toString(position));
                    startActivity(intent);

                }

            public void onNothingSelected(AdapterView<?> parent) {
                Log.d(LOG_TAG, "itemSelect: nothing");
            }
        });

    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();
        Intent intent;
        try
        {
            switch (id) {
                case R.id.action_settings:
                    intent = new Intent("Show.Settings12");
                    startActivity(intent);
                    return true;
                case R.id.action_about_athour:
                    intent = new Intent("About.MyProject");
                    startActivity(intent);
                    return true;
                case R.id.action_another:
                    intent = new Intent("About.MyProject.1");
                    startActivity(intent);
                    return true;
                default:
                    return super.onOptionsItemSelected(item);
            }
        }
        catch(Exception e)
        {
            Log.d(LOG_TAG, "itemSelect: "+e.toString());
            return true;
        }
        //return super.onOptionsItemSelected(item);
    }
}

