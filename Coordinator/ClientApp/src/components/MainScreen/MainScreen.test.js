import { render, screen } from '@testing-library/react';
import MainScreen from './MainScreen';

test('renders learn react link', () => {
  render(<MainScreen />);
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});
