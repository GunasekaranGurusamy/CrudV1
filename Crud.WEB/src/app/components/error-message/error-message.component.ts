import { Component, Input, SimpleChanges } from '@angular/core';
import { AbstractControl, UntypedFormControl, UntypedFormGroup } from '@angular/forms';
import { NgIf } from '@angular/common';
import { ValidationService } from '../../services/validation.service';

@Component({
  selector: 'error-message',
  template: `<div  *ngIf="isSubmitted" class="control-error-msg">
  <div class="error-msg" *ngIf="control.errors && changesSubmited">
  <p  *ngIf="control.errors['required'] && !control.errors['invalidDateFormat']">{{controlName}} {{getMessage('required')}}</p>
  <p  *ngIf="control.errors['email']">{{getMessage('email')}}</p>
  <p  *ngIf="control.errors['incorrect']">{{getMessage('incorrect')}}</p>
  <p  *ngIf="control.errors['invalidDateFormat']">{{getMessage('invalidDateFormat')}}</p>
  <p  *ngIf="control.errors['isExists']">{{getMessage('isExists')}}</p>
  <p  *ngIf="control.errors['maxlength']">{{getMessage('maxlength')}}</p>
  <p  *ngIf="control.errors['invalidFutureDate']">{{getMessage('invalidFutureDate')}}</p>
  <p  *ngIf="control.errors['invalidPastDate']">{{getMessage('invalidPastDate')}}</p>
  <p  *ngIf="control.errors['injection']">{{getMessage('injection')}}</p>
  </div>
</div>`,
  styles: [
    `.error-msg p {
  color: #981b1e;
  font-size: 12px;
  margin-top: 5px;
}`
  ],
  standalone: true,
  imports: [NgIf]
})
export class ErrorMessageComponent {
  @Input() control!: UntypedFormControl | UntypedFormGroup | AbstractControl;
  @Input() controlName!: string;
  @Input() isSubmitted: boolean = true;
  @Input() messageVariable!: string;

  changesSubmited: boolean = false;

  constructor(public validationService: ValidationService) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['isSubmitted'] && changes['isSubmitted'].currentValue) {
      this.changesSubmited = true;
    }
  }

  getMessage(type: string) {
    return ValidationService.errorMessage[type];
  }

}
