package com.example.opslagstavlenapp;

import android.graphics.Bitmap;

/**
 * Image object class
 *
 * This class is used to construct image objects.
 *
 * @author Benjamin Hoffmeyer
 * @version 1.0
 * @since 1.0
 */
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
