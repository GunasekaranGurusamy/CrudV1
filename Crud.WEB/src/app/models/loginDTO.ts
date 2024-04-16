export interface loginRequestDTO {
  userName: string;
  password: string;
}

export interface loginResponseDTO {
  token: string;
  refreshToken: string;
  expiry?: Date;
}
