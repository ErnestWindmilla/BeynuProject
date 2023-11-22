package com.unity3d.player;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import com.unity3d.player.UnityPlayerActivity;

public class DeepLinkActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        // Manejar el deep link
        handleDeepLink();
    }

    private void handleDeepLink() {
        Intent intent = getIntent();
        Uri data = intent.getData();

        if (data != null) {
            // Obtener el deep link
            String deepLink = data.toString();
            
            // Enviar el deep link a Unity
            UnityPlayer.UnitySendMessage("URLHandler", "HandleDeepLink", deepLink);
        }
    }
}