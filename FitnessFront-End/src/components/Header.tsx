import { NavLink } from 'react-router-dom';

const Header = () => {
  return (
<div className="bg-blue-500 text-white h-24 flex items-center justify-between px-6 m-0 p-0">
<p className="text-3xl font-thin">AllPhi Dashboard</p>
      <div className="flex gap-6">
        <NavLink
          to="/"
          className={({ isActive }) =>
            isActive ? "underline underline-offset-8 font-bold" : "no-underline"
          }
        >
          Home
        </NavLink>
      </div>
    </div>
  );
};

export default Header;
