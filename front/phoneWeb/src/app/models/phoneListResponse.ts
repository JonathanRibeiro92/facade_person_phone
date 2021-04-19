import { BaseResponse } from "./baseResponse";
import { Phone } from "./phone";

export class PhoneListResponse extends BaseResponse {
  phoneObjects : Phone[];
}
