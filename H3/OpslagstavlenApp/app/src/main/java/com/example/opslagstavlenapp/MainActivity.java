package com.example.opslagstavlenapp;

import android.Manifest;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.os.Bundle;
import android.provider.MediaStore;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

import androidx.activity.result.ActivityResult;
import androidx.activity.result.ActivityResultCallback;
import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

public class MainActivity extends AppCompatActivity {

    ActivityResultLauncher<Intent> activityLauncher = registerForActivityResult(
            new ActivityResultContracts.StartActivityForResult(),
            new ActivityResultCallback<ActivityResult>() {
                @Override
                public void onActivityResult(ActivityResult result) {
                    Intent intent = result.getData();
                    Bitmap photo = (Bitmap) intent.getExtras().get("data");
                    imageView.setImageBitmap(photo);
                }
            });

    private ImageView imageView;
    private Button button;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        imageView = findViewById(R.id.capturedImage);
        button = findViewById(R.id.openCamera);

        if(ContextCompat.checkSelfPermission(MainActivity.this, Manifest.permission.CAMERA)
                != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(MainActivity.this, new String[]{
                    Manifest.permission.CAMERA
            }, 100);
        }

        button.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                Intent open_camera = new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                activityLauncher.launch(open_camera);
            }
        });
    }

    float x, y;
    float dx, dy;
    @Override
    public boolean onTouchEvent(MotionEvent event){
        if(event.getAction()==MotionEvent.ACTION_DOWN){
            x = event.getX();
            y = event.getY();
        }

        if(event.getAction() == MotionEvent.ACTION_MOVE){
            dx = event.getX()-x;
            dy = event.getY()-y;

            imageView.setX(imageView.getX()+dx);
            imageView.setY(imageView.getY()+dy);

            x = event.getX();
            y = event.getY();
        }

        return super.onTouchEvent(event);
    }
}