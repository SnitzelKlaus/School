package com.example.opslagstavlenapp;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.List;

public class InternalStorage {

    public static void saveImage(Context context, Bitmap bitmap, String name, String extension){

        // Directory path to save image
        File directory = context.getDir("images", Context.MODE_PRIVATE);

        // Creates file path
        File path = new File(directory, name + "." + extension);

        FileOutputStream fileOutputStream = null;
        try{
            fileOutputStream = new FileOutputStream(path);
            bitmap.compress(Bitmap.CompressFormat.JPEG, 90, fileOutputStream);
        }catch (Exception e){
            e.printStackTrace();
        }finally{
            try{
                fileOutputStream.close();
            }catch (Exception e){
                e.printStackTrace();
            }
        }
    }

    public List<Image> loadImages(Context context){
        List<Image> imageViews = new ArrayList<>();

        // Directory path to get image
        File directory = context.getDir("images", Context.MODE_PRIVATE);

        for(File file : directory.listFiles()){
            Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
            String name = file.getName().substring(0, file.getName().lastIndexOf("."));
            String extension = file.getName().substring(file.getName().lastIndexOf(".") + 1);
            imageViews.add(new Image(bitmap, name, extension));
        }

        return imageViews;
    }

    public void deleteImages(Context context){
        // Directory path to delete image
        File directory = context.getDir("images", Context.MODE_PRIVATE);

        // Deletes all files in directory
        for(File file : directory.listFiles()){
            file.delete();
        }
    }
}
