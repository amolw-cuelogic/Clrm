import { Component, OnInit } from '@angular/core';
import { User } from '../model/user'
import { AppconfigService } from '../service/appconfig.service'

@Component({
    selector: 'app-dashboard',
    templateUrl: './full-layout.component.html',
    providers: [AppconfigService]
})
export class FullLayoutComponent implements OnInit {

    public disabled = false;
    public status: { isopen: boolean } = { isopen: false };

    user: User = this.srvAppconfig.GetToken();

    constructor(private srvAppconfig: AppconfigService) {
        //this.user = this.srvAppconfig.GetToken();
    }

    public toggled(open: boolean): void {
        console.log('Dropdown is now: ', open);
    }

    public toggleDropdown($event: MouseEvent): void {
        $event.preventDefault();
        $event.stopPropagation();
        this.status.isopen = !this.status.isopen;
    }

    ngOnInit(): void {
        
    }
}
