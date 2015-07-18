package com.example.alex.try3;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.media.Image;
import android.widget.Toast;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

import android.app.Activity;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.View;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.InetAddress;
import java.net.Socket;

/**
 * Created by Alex on 16.04.2015.
 */
public class ImageFind
{
    public void SendImageForSearch(Context context,String arr_str)
    {
        int serverPort = 3000; // здесь обязательно нужно указать порт к которому привязывается сервер.
        String address = "192.168.56.1"; // это IP-адрес компьютера, где исполняется наша серверная программа.
        //System.out.println("before try");
        try {
            Socket socket = new Socket(address, serverPort);
            InputStream sin = socket.getInputStream();
            OutputStream sout = socket.getOutputStream();
            DBHelper db=new DBHelper(context);
            final SQLiteDatabase db1=db.getWritableDatabase();
            Boolean boolValue=MyFindById(arr_str,db1);
            if(!boolValue) return;
            //System.out.println("after try");
            /*Toast.makeText(context,
                    "происходит шаг 1 после try", Toast.LENGTH_SHORT).show();*/
            //Log.d("FirstChek","происходит шаг 1 после try");
            // создаем объект который отображает вышеописанный IP-адрес.
             // создаем сокет используя IP-адрес и порт сервера.
            //Log.d("FirstChek","происходит шаг 2 после try");

           //System.out.println("after Socket1");
            // Конвертируем потоки в другой тип, чтоб легче обрабатывать текстовые сообщения.
            DataInputStream in = new DataInputStream(sin);
            DataOutputStream out = new DataOutputStream(sout);
            /*Toast.makeText(context,
                    "происходит шаг 3 после try", Toast.LENGTH_SHORT).show();*/
            //Log.d("FirstChek","происходит шаг 3 после try");
            // Создаем поток для чтения с клавиатуры.
            //BufferedReader keyboard = new BufferedReader(new InputStreamReader(System.in));
            String line = null;
            out.writeUTF(arr_str); // отсылаем введенную строку текста серверу.
            out.flush();
            //System.out.println("result: 1");
            line = in.readUTF(); // ждем пока сервер отошлет строку текста.
            //System.out.println("result: " + line);
            boolean MatchThisWorld=line.equals("true");
            Log.d("MyLogs","MatchThisWorld="+MatchThisWorld+" boolValue="+boolValue);
            //Log.d("MyLogs","Есть ли данная картинка в базе?: "+String.valueOf(!boolValue));
            if(!MatchThisWorld)
            {
                Toast.makeText(context, "Данного изображения нет у сервера.", Toast.LENGTH_SHORT).show();
            }
            else
            {
                if(!boolValue)  Toast.makeText(context, "Данное изображение уже скачано.", Toast.LENGTH_SHORT).show();
            }
            if (MatchThisWorld && boolValue)
            {
                line = in.readUTF();
                byte[] mybytearray;
                try {
                    mybytearray = new byte[Integer.valueOf(line)];
                    Log.d("MyLogs","result size: " + Integer.valueOf(line));
                } catch (Exception e) {
                    mybytearray = new byte[998998];
                }
                /*byte[] mybytearray = new byte[1024];
                InputStream is = sock.getInputStream();
                FileOutputStream fos = new FileOutputStream("s.pdf");
                BufferedOutputStream bos = new BufferedOutputStream(fos);
                int bytesRead = is.read(mybytearray, 0, mybytearray.length);
                bos.write(mybytearray, 0, bytesRead);
                bos.close();
                sock.close();*/
                InputStream is = socket.getInputStream();
                FileOutputStream fos = new FileOutputStream("data//data//com.example.alex.try3//"+arr_str+".bmp");
                BufferedOutputStream bos = new BufferedOutputStream(fos);
                /*int bytesRead = is.read(mybytearray, 0, mybytearray.length);
                Log.d("MyLogsr", String.valueOf(bytesRead));
                bos.write(mybytearray, 0, bytesRead);
                bos.close();
                socket.close();*/
                //
                int numread;
                byte[] buffer=new byte[256]; // use whatever buffer size is appropriate for your device
                do
                {
                    numread = is.read(buffer, 0, 256);
                    if (numread <= 0) break;
                    bos.write(buffer, 0, numread);

                }
                while (true);
                bos.close();
                socket.close();
                //.........................
               //Log.d("MyLogs", "Insert: "+arr_str+"!!!*");
                db1.execSQL("insert into 'photo' ('id') values ('"+arr_str+"')");
                db1.close();
                db.close();
               // return true;
            }
           // return false;
        } catch (Exception x) {
            //x.printStackTrace();
             Toast.makeText(context,
                    "Сервер не найден.", Toast.LENGTH_SHORT).show();
        }
    }

    public boolean MyFindById(String str,SQLiteDatabase db1)
    {
        Cursor c = db1.query("photo", null, null, null, null, null, null);
        try {
            if (c.moveToFirst()) {
                int indexForPhoto = c.getColumnIndex("id");
                do {
                    //Log.d("MyLogsF", "id= "+c.getString(indexForPhoto));
                    Log.d("MyLogsf", "id= "+c.getString(indexForPhoto));
                    if (str.equals(c.getString(indexForPhoto))) return false;
                    //Log.d("MyLogs", "id= "+c.getString(indexForPhoto));
                }
                while (c.moveToNext());
            }
            //c.close();
            return true;
        }
        catch (Exception e)
        {
            Log.d("MyLogs", "!!!!Exception на Select");
            return false;
        }
        finally
        {
            c.close();
            Log.d("MyLogs", "проверка на повторения окончена!");
        }
    }
}
