package com.example.alex.try3;

import java.util.ArrayList;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.CompoundButton.OnCheckedChangeListener;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import static android.support.v4.app.ActivityCompat.startActivity;

public class BoxAdapter extends BaseAdapter
{
    Context ctx;
    LayoutInflater lInflater;
    ArrayList<Product> objects;
    Intent intent;
    Bundle savedInstanceState;
   // a.loadText();
    BoxAdapter(Context context, ArrayList<Product> products,Bundle savedInstanceState)
    {
        this.savedInstanceState=savedInstanceState;
        ctx = context;
        objects = products;
        lInflater = (LayoutInflater) ctx
                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    // кол-во элементов
    @Override
    public int getCount() {
        return objects.size();
    }

    // элемент по позиции
    @Override
    public Object getItem(int position) {
        return objects.get(position);
    }

    // id по позиции
    @Override
    public long getItemId(int position) {
        return position;
    }

    // пункт списка
    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        // используем созданные, но не используемые view
        View view = convertView;
        if (view == null) {
            view = lInflater.inflate(R.layout.myitem_formonths, parent, false);
        }
        final Product p = getProduct(position);

        // заполняем View в пункте списка данными из товаров: наименование, цена
        // и картинка
        final TextView Tv1=(TextView) view.findViewById(R.id.tvDescr);
        ((TextView) view.findViewById(R.id.tvDescr)).setText(p.name);
        TextView Tv2 =(TextView) view.findViewById(R.id.tvPrice);
        ((TextView) view.findViewById(R.id.tvPrice)).setText(p.text + "");

        ImageView Imv=(ImageView) view.findViewById(R.id.ivImage);
        if (findDay(p.date))
        {
            int strId1 = ctx.getResources().getIdentifier("drawable/"+p.date, "drawable", ctx.getPackageName());
            Imv.setImageResource(strId1);
        }
        else
        {
            ((ImageView) view.findViewById(R.id.ivImage)).setImageResource(p.image);
        }
        LinearLayout Linl=(LinearLayout) view.findViewById(R.id.linearLayout1);
       /* view.setOnClickListener(new View.OnClickListener()
        {
            public void onClick(View v)
            {
                //Toast.makeText (ctx, "Long click on  in position  and it is removed now!"+position, Toast.LENGTH_LONG).show();
            }
        });*/

        CheckBox cbBuy = (CheckBox) view.findViewById(R.id.cbBox);
        // присваиваем чекбоксу обработчик
        cbBuy.setOnCheckedChangeListener(myCheckChangList);
        // пишем позицию
        cbBuy.setTag(position);
        // заполняем данными из товаров: в корзине или нет
        cbBuy.setChecked(p.box);

        Tv1.setTag(position);
        Tv2.setTag(position);
        Linl.setOnClickListener(new View.OnClickListener() {

    @Override
    public void onClick(View v) {
        Object a= Tv1.getTag();
        //intent.putExtra("month",Integer.toString(position));
        Toast.makeText(ctx,
                p.text, Toast.LENGTH_SHORT).show();
               /* Toast.makeText(ctx,
                        "элемент "+a, Toast.LENGTH_SHORT).show();*/
        intent = new Intent();
        intent=new Intent("Show.activity.Infomonth");

        intent.putExtra("info",p.name+"\n"+p.text);
        intent.putExtra("date",p.date);
       // intent.putExtra("position",position);
        startActivity((Activity)ctx,intent,savedInstanceState);
        //intent[0]=new Intent("Show.Settings12");
        //startActivities(ctx,intent);
    }
});
        Tv1.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Object a = Tv1.getTag();
                /*Toast.makeText(ctx,
                        "элемент "+a, Toast.LENGTH_SHORT).show();*/
                Toast.makeText(ctx,
                        p.text, Toast.LENGTH_SHORT).show();
                intent = new Intent();
                intent=new Intent("Show.activity.Infomonth");


                intent.putExtra("date",p.date);
                intent.putExtra("info",p.name+"\n"+p.text);
               // intent.putExtra("position",position);
                startActivity((Activity)ctx,intent,savedInstanceState);
            }
        });
        Tv2.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Object a= Tv1.getTag();
                //intent.putExtra("month",Integer.toString(position));
                Toast.makeText(ctx,
                        p.text, Toast.LENGTH_SHORT).show();
               /* Toast.makeText(ctx,
                        "элемент "+a, Toast.LENGTH_SHORT).show();*/
                intent = new Intent();
                intent=new Intent("Show.activity.Infomonth");

                intent.putExtra("info",p.name+"\n"+p.text);
                intent.putExtra("date",p.date);
               // intent.putExtra("position",position);
                startActivity((Activity)ctx,intent,savedInstanceState);
                //intent[0]=new Intent("Show.Settings12");
               //startActivities(ctx,intent);
            }
        });
        Imv.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Object a= Tv1.getTag();
                Toast.makeText(ctx,
                        p.text, Toast.LENGTH_SHORT).show();
              /* Toast.makeText(ctx,
                        "элемент "+a, Toast.LENGTH_SHORT).show();*/
                intent = new Intent();
                intent=new Intent("Show.activity.Infomonth");
                intent.putExtra("date",p.date);
                intent.putExtra("info",p.name+"\n"+p.text);
                //intent.putExtra("position",position);
                startActivity((Activity) ctx, intent, savedInstanceState);
           }
        });
        return view;
    }
    // товар по позиции
    Product getProduct(int position) {
        return ((Product) getItem(position));
    }
    // содержимое корзины
    ArrayList<Product> getBox() {
        ArrayList<Product> box = new ArrayList<Product>();
        for (Product p : objects) {
            // если в корзине
            if (p.box)
                box.add(p);
        }
        return box;
    }
    // обработчик для чекбоксов
    OnCheckedChangeListener myCheckChangList = new OnCheckedChangeListener() {
        public void onCheckedChanged(CompoundButton buttonView,
                                     boolean isChecked) {
            // меняем данные товара (в корзине или нет)
            getProduct((Integer) buttonView.getTag()).box = isChecked;
        }
    };
    public boolean findDay(String day)
    {
        String[] days = ctx.getResources().getStringArray(R.array.daysofyearforcode);
        for(String a: days)
        {
            //Log.d(LOG_TAG, "mass:" + a+ " ? "+day+".");
            if (day.equals(a)) return true;
        }
        return false;
    }
}