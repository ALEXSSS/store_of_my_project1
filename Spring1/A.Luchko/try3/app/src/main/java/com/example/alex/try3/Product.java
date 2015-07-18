package com.example.alex.try3;

public class Product {

    String name;
    String text;
    String date;
    int image;
    boolean box;


    Product(String _describe, String _text, String date, int _image, boolean _box) {
        name = _describe;
        text = _text;
        image = _image;
        box = _box;
        this.date=date;
    }
}