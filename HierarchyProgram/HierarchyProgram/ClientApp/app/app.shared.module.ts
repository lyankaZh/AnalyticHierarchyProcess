import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { ComparisonComponent } from './components/comparison/comparison.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { MatSliderModule } from '@angular/material/slider';


@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        ComparisonComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        //MatSliderModule,
        RouterModule.forRoot([
            { path: '', redirectTo: '/Home', pathMatch: 'full' },
            {
                path: 'Home',
                component: HomeComponent
            },
            {
                path: 'Comparison',
                component: ComparisonComponent
            },

            { path: '**', redirectTo: 'Home' }
        ])
    ]
})
export class AppModuleShared {
}
