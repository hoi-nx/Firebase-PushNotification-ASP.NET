package com.mteam.firebase_professional;

import com.google.firebase.iid.FirebaseInstanceId;
import com.google.firebase.iid.FirebaseInstanceIdService;

/**
 * Created by Stealer Of Souls on 4/2/2018.
 */

public class MyFirebaseInstanceIDService extends FirebaseInstanceIdService {

    @Override
    public void onTokenRefresh() {
        super.onTokenRefresh();
        String token= FirebaseInstanceId.getInstance().getToken();

        saveTokenToServer(token);
    }

    private void saveTokenToServer(String token) {
        new FirebaseIDTask().execute(token);

    }
}
