export class MyString {
    private str: string;
  
    constructor(str: string) {
      this.str = str;
    }
  
    remove(index: number): string {
      if (index < 0 || index >= this.str.length) {
        return this.str;
      }
      return this.str.slice(0, index) + this.str.slice(index + 1);
    }
  
    insert(index: number, sign: string): string {
      if (index < 0) {
        return sign + this.str;
      }
      if (index > this.str.length) {
        return this.str + sign;
      }
      return this.str.slice(0, index) + sign + this.str.slice(index);
    }
  
    trimSign(): string {
      return this.str.replace(/(.)\1+/g, "$1");
    }
  
    toggle(): string {
      return this.str.split('').map(char => {
        if (char === char.toUpperCase()) {
          return char.toLowerCase();
        } else {
          return char.toUpperCase();
        }
      }).join('');
    }
  
    counter(sign: string): number {
      return this.str.split(sign).length - 1;
    }
  }  