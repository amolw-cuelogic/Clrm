import { Injectable } from '@angular/core';
import { AngularFireAuth, AngularFireAuthProvider, AngularFireAuthModule } from 'angularfire2/auth';
import * as firebase from 'firebase/app';

@Injectable()
export class AuthService {

    constructor(public af: AngularFireAuth) { }

    loginWithGoogle() {
        return this.af.auth.signInWithPopup(new firebase.auth.GoogleAuthProvider());
    }
    logoutFromGoogle() {
        return this.af.auth.signOut();
    }
}
