import { NgModule, NgModuleFactory, NgModuleFactoryLoader, RendererFactory2, NgZone } from '@angular/core';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { ServerModule, ɵServerRendererFactory2 } from '@angular/platform-server';
import { ɵAnimationEngine } from '@angular/animations/browser';
import { NoopAnimationsModule, ɵAnimationRendererFactory } from '@angular/platform-browser/animations';
//import { NgZorroAntdModule } from 'ng-zorro-antd';

// declarations
export function instantiateServerRendererFactory(
    renderer: RendererFactory2, engine: ɵAnimationEngine, zone: NgZone) {
    return new ɵAnimationRendererFactory(renderer, engine, zone);
}

const createRenderer = ɵServerRendererFactory2.prototype.createRenderer;
ɵServerRendererFactory2.prototype.createRenderer = function () {
    const result = createRenderer.apply(this, arguments);
    const setProperty = result.setProperty;
    result.setProperty = function () {
        try {
            setProperty.apply(this, arguments);
        } catch (e) {
            if (e.message.indexOf('Found the synthetic') === -1) {
                throw e;
            }
        }
    };
    return result;
}

export const SERVER_RENDER_PROVIDERS = [
    {
        provide: RendererFactory2,
        useFactory: instantiateServerRendererFactory,
        deps: [ɵServerRendererFactory2, ɵAnimationEngine, NgZone]
    }
];

@NgModule({
    bootstrap: [AppComponent],
    imports: [
        ServerModule,
        AppModuleShared,
        NoopAnimationsModule
        //NgZorroAntdModule.forRoot()
    ],
    providers: [SERVER_RENDER_PROVIDERS]
})
export class AppModule {
}
