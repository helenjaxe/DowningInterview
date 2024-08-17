export interface ICompany {
  companyName: string;
  code: string;
  sharePrice? : number
  createdDate?: Date;
}

export interface ICompanyAdd {
  companyName: string;
  code: string;
  sharePrice?: number
}
