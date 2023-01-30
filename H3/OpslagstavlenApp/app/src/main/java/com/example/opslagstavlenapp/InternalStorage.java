package com.example.opslagstavlenapp;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Log;

import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.List;

/**
 * Internal Storage for images
 *
 * This class is used for loading/saving/deleting images to internal storage.
 *
 * @author Benjamin Hoffmeyer
 * @version 1.0
 * @since 1.0
 */
public class InternalStorage {

    /**
     * Method that saves images to internal storage.
     *
     * @param context The context of current app state. (Used to determine filepath)
     * @param bitmap The bitmap of image.
     * @param name The name/id of image.
     * @param extension The extension of image (jpg, png, svg).
     * @result Saves the image (bitmap, name, extension) to internal storage
     */
    public static void saveImage(Context context, Bitmap bitmap, String name, String extension){

        // Directory path to save image
        File directory = context.getDir("images", Context.MODE_PRIVATE);

        // Creates file path
        File path = new File(directory, name + "." + extension);

        // File stream for saving data
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


    /**
     * Method that loads images from internal storage
     *
     * @param context The context of current app state. (Used to determine filepath)
     * @return List of images with the following attributes: 'bitmap, name, extension'
     */
    public List<Image> loadImages(Context context){
        List<Image> images = new ArrayList<>();

        // Directory path to get image
        File directory = context.getDir("images", Context.MODE_PRIVATE);

        // Loops through files and adds to list of images
        for(File file : directory.listFiles()){
            Bitmap bitmap = BitmapFactory.decodeFile(file.getAbsolutePath());
            String name = file.getName().substring(0, file.getName().lastIndexOf("."));
            String extension = file.getName().substring(file.getName().lastIndexOf(".") + 1);

            images.add(new Image(bitmap, name, extension));
        }

        return images;
    }


    /**
     * Method that deletes all images.
     *
     * @param context The context of current app state. (Used to determine filepath)
     * @return The deletion of ALL files in directory: 'images'
     */
    public void deleteImages(Context context){
        // Directory path to delete image
        File directory = context.getDir("images", Context.MODE_PRIVATE);

        // Deletes all files in directory
        for(File file : directory.listFiles()){
            file.delete();
        }
    }
}
