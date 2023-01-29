package com.example.opslagstavlenapp;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RelativeLayout;

import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

/**
 * Main Activity for application
 *
 * The first activity that loads for the application.
 *
 * @author Benjamin Hoffmeyer
 * @version 1.0
 * @since 1.0
 */
public class MainActivity extends AppCompatActivity {
    private final List<ImageView> _imageViews = new ArrayList<>();
    private RelativeLayout _boardLayout;
    ActivityResultLauncher<Intent> activityLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            new ActivityResultCallback<ActivityResult>() {
                @Override
                public void onActivityResult(ActivityResult result) {
                    Intent intent = result.getData();
                    assert intent != null;
                    Bitmap bitmap = (Bitmap) intent.getExtras().get("data");
                    createImageView(bitmap, null);
                }
            });


    /**
     * Method that starts on startup
     *
     * @param savedInstanceState Activities have the ability, under special circumstances,
     *                           to restore themselves to a previous state using the data
     *                           stored in this bundle.
     */
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);
        Button cameraButton = findViewById(R.id.openCamera);
        Button deleteButton = findViewById(R.id.deleteBoard);
        Button saveButton = findViewById(R.id.saveBoard);
        _boardLayout = findViewById(R.id.board);

        loadImages();

        if(ContextCompat.checkSelfPermission(MainActivity.this, Manifest.permission.CAMERA)
                != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(MainActivity.this, new String[]{
                    Manifest.permission.CAMERA
            }, 100);
        }

        cameraButton.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                Intent open_camera = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                activityLauncher.launch(open_camera);
            }
        });

        deleteButton.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                // Delete images from internal storage
                InternalStorage internalStorage = new InternalStorage();
                internalStorage.deleteImages(MainActivity.this);

                _boardLayout.removeAllViews();
                _imageViews.clear();
            }
        });
        saveButton.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                // Save images to internal storage
                InternalStorage internalStorage = new InternalStorage();
                for(ImageView imageView : _imageViews){
                    Bitmap bitmap = imageView.getDrawingCache();
                    InternalStorage.saveImage(MainActivity.this, bitmap, String.valueOf(imageView.getId()), "jpg");
                }
            }
        });
    }


    /**
     * Method that loads images from internal storage and API (in progress)
     *
     * @return Void: Creates new imageViews from storage and API (in progress)
     */
    private void loadImages(){
        // Load images from internal storage
        InternalStorage internalStorage = new InternalStorage();
        List<Image> images = internalStorage.loadImages(this);
        for(Image image : images){
            createImageView(image.getBitmap(), String.valueOf(image.getName()));
        }
    }


    /**
     * Method that creates new imageView
     *
     * @param bitmap The bitmap of image
     * @param uniqueID The name/id of image
     * @return Void: Creates new imageView and adds it to '_boardLayout' and list '_imageViews'
     */
    @SuppressLint("ClickableViewAccessibility")
    private void createImageView(Bitmap bitmap, String uniqueID){
        ImageView imageView = new ImageView(this);
        imageView.setImageBitmap(bitmap);
        imageView.setAdjustViewBounds(true);
        imageView.setMaxHeight(500);
        imageView.setMaxWidth(500);

        if (uniqueID == null) {
            // Create unique id
            uniqueID = UUID.randomUUID().toString();
        }

        // Sets id to imageview
        imageView.setId(uniqueID.hashCode());

        _boardLayout.addView(imageView);
        _imageViews.add(imageView);

        imageView.setOnTouchListener(new View.OnTouchListener() {
            @SuppressLint("ClickableViewAccessibility")
            float x, y;
            float dx, dy;
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if(event.getAction() == MotionEvent.ACTION_DOWN){
                    x = event.getRawX();
                    y = event.getRawY();
                }
                if(event.getAction() == MotionEvent.ACTION_MOVE){
                    dx = event.getRawX()-x;
                    dy = event.getRawY()-y;

                    imageView.setX(imageView.getX()+dx);
                    imageView.setY(imageView.getY()+dy);

                    x = event.getRawX();
                    y = event.getRawY();
                }
                return true;
            }
        });
    }
}