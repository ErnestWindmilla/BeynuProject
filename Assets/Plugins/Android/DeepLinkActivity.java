package com.unity3d.player;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;

public class DeepLinkActivity extends UnityPlayerActivity 
{

    @Override
    protected void onCreate(Bundle savedInstanceState) 
    {
        super.onCreate(savedInstanceState);
        handleDeepLink(getIntent());
    }

    private void handleDeepLink(Intent intent) 
    {
        Uri data = intent.getData();
        if (data != null) 
        {
            UnityPlayer.UnitySendMessage("URLHandler", "HandleDeepLink", data.toString());
        }
    }
}