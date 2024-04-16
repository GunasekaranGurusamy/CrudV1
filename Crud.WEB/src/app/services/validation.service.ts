import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  constructor() { }

  private static requiredMessage = " is required.";
  private static maxLengthMessage = "Maximum characters exceeded.";
  private static invalidFormatMessage = "Invalid format.";
  private static invalidDateMessage = "Invalid date.";
  private static invalidFutureDate = "Future date is not allowed.";
  private static invalidPastDate = "Past date is not allowed.";
  private static sqlInjection = "Please enter the text without '='.";
  private static isExists: 'Identifier already exists.';

  static validationMessages: { [key: string]: { [key: string]: string } } = {

    required: { required: ValidationService.requiredMessage },
    maxLength: { required: ValidationService.requiredMessage, maxlength: ValidationService.maxLengthMessage },
    EmailId: { required: ValidationService.requiredMessage, incorrect: ValidationService.invalidFormatMessage },
    date: {
      required: ValidationService.requiredMessage, incorrect: ValidationService.invalidDateMessage, invalidDateFormat: ValidationService.invalidDateMessage,
      invalidFutureDate: ValidationService.invalidFutureDate, invalidPastDate: ValidationService.invalidPastDate
    },
    sqlInjection: { injection: ValidationService.sqlInjection }
  };

  static errorMessage: { [key: string]: string } = {
    required: ValidationService.requiredMessage,
    incorrect: ValidationService.invalidFormatMessage,
    invalidDateFormat: ValidationService.invalidDateMessage,
    isExists: ValidationService.isExists,
    maxlength: ValidationService.maxLengthMessage,
    invalidFutureDate: ValidationService.invalidFutureDate,
    invalidPastDate: ValidationService.invalidPastDate,
    injection: ValidationService.sqlInjection,
    email: ValidationService.invalidFormatMessage
  }

}
