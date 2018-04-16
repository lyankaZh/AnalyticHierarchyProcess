import { Component, OnInit } from '@angular/core';

@Component({
    templateUrl: './comparison.component.html',
    styleUrls: ['./comparison.component.css']
})
export class ComparisonComponent implements OnInit {
    constructor() {

    }
    totalCountOfCriterias: number = 5;
    comparisonElements: any[];
    userSelectedResults: any[];

    firstSelectedCriteria: number = 0;
    secondSelectedCriteria: number = 1;
    isCompleteButtonDisabled: boolean = false;

    value: number = 0;


    ngOnInit(): void {
        this.comparisonElements = [
            {
                name: 'A1'
            },
            {
                name: 'A2'
            },
            {
                name: 'A3'
            },
            {
                name: 'A4'
            },
            {
                name: 'A5'
            }
        ]
    }

    navigatePrevious(): void {
        if (this.secondSelectedCriteria === this.firstSelectedCriteria + 1) {
            if (this.firstSelectedCriteria > 0) {
                this.firstSelectedCriteria--;
                this.secondSelectedCriteria = this.totalCountOfCriterias - 1;
            }
        } else {
            this.secondSelectedCriteria--;
        }
    }

    navigateNext(): void {
        if (this.secondSelectedCriteria === this.totalCountOfCriterias - 1) {
            if (this.firstSelectedCriteria < this.totalCountOfCriterias - 2) {
                this.firstSelectedCriteria++;
                this.secondSelectedCriteria = this.firstSelectedCriteria + 1;
            }
        } else {
            this.secondSelectedCriteria++;
        }
    }

    isNextButtonDisabled(): boolean {
        return this.secondSelectedCriteria === this.totalCountOfCriterias - 1 && this.firstSelectedCriteria === this.totalCountOfCriterias - 2;
    }

    isPreviousButtonDisabled(): boolean {
        return this.firstSelectedCriteria === 0 && this.secondSelectedCriteria === 1;
    }

    getScaleText(): void {

    }
}
