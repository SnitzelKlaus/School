package com.example.opslagstavlenapp;

import android.graphics.Bitmap;

public class Image {
    private Bitmap _bitmap;
    private String _name;
    private String _extension;

    public Image(Bitmap bitmap, String name, String extension) {
        _bitmap = bitmap;
        _name = name;
        _extension = extension;
    }

    public Bitmap getBitmap() {
        return _bitmap;
    }

    public String getName() {
        return _name;
    }

    public String getExtension() {
        return _extension;
    }
}
