import { MyString } from './myString';

describe('MyString', () => {
  test('remove() should remove character at specified index', () => {
    const myStr = new MyString('qwerty');
    expect(myStr.remove(0)).toBe('werty');
    expect(myStr.remove(5)).toBe('qwert');
    expect(myStr.remove(6)).toBe('qwerty');
    expect(myStr.remove(-1)).toBe('qwerty');
  });

  test('insert() should insert sign at specified index', () => {
    const myStr = new MyString('qwerty');
    expect(myStr.insert(0, 'a')).toBe('aqwerty');
    expect(myStr.insert(6, 'a')).toBe('qwertya');
    expect(myStr.insert(-1, 'a')).toBe('aqwerty');
    expect(myStr.insert(10, 'a')).toBe('qwertya');
  });

  test('trimSign() should remove consecutive duplicate characters', () => {
    const myStr = new MyString('qqwwweerrttyy');
    expect(myStr.trimSign()).toBe('qwerty');
  });

  test('toggle() should toggle case of all characters', () => {
    const myStr = new MyString('qWeRtY');
    expect(myStr.toggle()).toBe('QwErTy');
  });

  test('counter() should count occurrences of a sign', () => {
    const myStr = new MyString('qwertyqwerty');
    expect(myStr.counter('q')).toBe(2);
    expect(myStr.counter('w')).toBe(2);
    expect(myStr.counter('z')).toBe(0);
  });
});