import { useMemberGet } from "./endpoints/fitnessComponents";

function App() {
  const members = useMemberGet({});
  return (
    <>
    {members.isLoading && <div>Loading</div>}
    {members.error && <div>{members.error.payload.toString()}</div>}
      {members.data != null && (
        <div>
          {members.data.map((member) => 
            <p>{member.firstName}</p>
          )}
        </div>
      )}
    </>
  );
}

export default App;
